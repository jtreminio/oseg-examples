package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PutContextKindExample
{
    fun putContextKind()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val upsertContextKindPayload = UpsertContextKindPayload(
            name = "organization",
            description = "An example context kind for organizations",
            hideInTargeting = false,
            archived = false,
            version = 1,
        )

        try
        {
            val response = ContextsApi().putContextKind(
                projectKey = null,
                key = null,
                upsertContextKindPayload = upsertContextKindPayload,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling ContextsApi#putContextKind")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling ContextsApi#putContextKind")
            e.printStackTrace()
        }
    }
}
