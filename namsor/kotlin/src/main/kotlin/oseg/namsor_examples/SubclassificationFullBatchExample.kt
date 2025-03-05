package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map

class SubclassificationFullBatchExample
{
    fun subclassificationFullBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameGeoIn(
            id = "id",
            name = "name",
            countryIso2 = "countryIso2",
        )

        val personalNames2 = PersonalNameGeoIn(
            id = "id",
            name = "name",
            countryIso2 = "countryIso2",
        )

        val personalNames = arrayListOf<PersonalNameGeoIn>(
            personalNames1,
            personalNames2,
        )

        val batchPersonalNameGeoIn = BatchPersonalNameGeoIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().subclassificationFullBatch(
                batchPersonalNameGeoIn = batchPersonalNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#subclassificationFullBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#subclassificationFullBatch")
            e.printStackTrace()
        }
    }
}
