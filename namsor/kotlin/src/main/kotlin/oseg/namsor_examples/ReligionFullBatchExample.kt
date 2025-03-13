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
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class ReligionFullBatchExample
{
    fun religionFullBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameGeoSubdivisionIn(
            id = "id",
            name = "name",
            countryIso2 = "countryIso2",
            subdivisionIso = "subdivisionIso",
        )

        val personalNames2 = PersonalNameGeoSubdivisionIn(
            id = "id",
            name = "name",
            countryIso2 = "countryIso2",
            subdivisionIso = "subdivisionIso",
        )

        val personalNames = arrayListOf<PersonalNameGeoSubdivisionIn>(
            personalNames1,
            personalNames2,
        )

        val batchPersonalNameGeoSubdivisionIn = BatchPersonalNameGeoSubdivisionIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().religionFullBatch(
                batchPersonalNameGeoSubdivisionIn = batchPersonalNameGeoSubdivisionIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#religionFullBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#religionFullBatch")
            e.printStackTrace()
        }
    }
}
