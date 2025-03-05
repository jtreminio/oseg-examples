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

class GenderFullBatchExample
{
    fun genderFullBatch()
    {
        ApiClient.apiKey["api_key"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameIn(
            id = "0f472330-11a9-49ad-a0f5-bcac90a3f6bf",
            name = "Keith Haring",
        )

        val personalNames = arrayListOf<PersonalNameIn>(
            personalNames1,
        )

        val batchPersonalNameIn = BatchPersonalNameIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().genderFullBatch(
                batchPersonalNameIn = batchPersonalNameIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#genderFullBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#genderFullBatch")
            e.printStackTrace()
        }
    }
}
